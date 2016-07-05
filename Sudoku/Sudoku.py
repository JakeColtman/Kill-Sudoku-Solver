from random import choice


class Square:
    def __init__(self):
        self.possible_values = [1, 2, 3, 4, 5, 6, 7, 8, 9]

    def is_fixed(self):
        len(self.possible_values) == 1

    def remove_possible_value(self, value):
        try:
            self.possible_values.remove(value)
        except:
            pass


def update_squares_through_row(grid, ypos, x_pos, value):
    for i in range(len(grid)):
        grid[ypos][i].remove_possible_value(value)
    return grid


def update_squares_through_col(grid, ypos, x_pos, value):
    for i in range(len(grid)):
        grid[i][x_pos].remove_possible_value(value)
    return grid


def update_squares_through_box(grid, y_pos, x_pos, value):
    for i in range(len(grid)):
        for j in range(len(grid)):
            if i// 3 == y_pos // 3 and j // 3 == x_pos// 3:
                grid[i][j].remove_possible_value(value)
    return grid

class Sudoku:
    def __init__(self, updaters = None):
        self.size = 9
        self.reset()
        if updaters is None:
            updaters = [update_squares_through_col, update_squares_through_row, update_squares_through_box]
        self.updaters = updaters

    def generate_new_values(self):
        for i in range(self.size):
            for j in range(self.size):
                self.set_value(i, j, choice(self.grid[i][j].possible_values))

    def set_value(self, y_pos, x_pos, new_value):
        for update in self.updaters:
            self.grid = update(self.grid, y_pos, x_pos, new_value)
        self.grid[y_pos][x_pos].possible_values = [new_value]

    def solve(self):
        counter = 0
        while not self.validate():
            self.reset()
            try:
                self.generate_new_values()
            except:
                pass
            counter += 1
            if counter % 1000 == 0:
                print(counter)
        self.print()
        return self.grid

    def validate(self):

        def list_contains_only_unique_elements(group):
            return len([x.possible_values[0] for x in group]) == len(list(set([x.possible_values[0] for x in group])))

        def generate_rows():
            output = []
            for i in range(self.size):
                output.append([x for x in self.grid[i]])
            return output

        def generate_columns():
            output = []
            for i in range(self.size):
                column = []
                for j in range(self.size):
                    column.append(self.grid[j][i])
                output.append(column)
            return output

        def run():
            for row in generate_rows():
                if not list_contains_only_unique_elements(row):
                    return False
            for col in generate_columns():
                if not list_contains_only_unique_elements(col):
                    return False
            return True

        try:
            return run()
        except:
            return False

    def reset(self):
        self.grid = []
        for i in range(self.size):
            self.grid.append([])
            for j in range(self.size):
                self.grid[-1].append(Square())

    def print(self):
        for i in range(self.size):
            print([x.possible_values for x in self.grid[i]])