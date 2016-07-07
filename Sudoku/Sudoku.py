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
        while True:
            self.reset()
            try:
                self.generate_new_values()
                break
            except:
                pass
            counter += 1
            if counter % 1000 == 0:
                print(counter)
        self.print()
        return self.grid

    def reset(self):
        self.grid = []
        for i in range(self.size):
            self.grid.append([])
            for j in range(self.size):
                self.grid[-1].append(Square())

    def print(self):
        for i in range(self.size):
            print([x.possible_values for x in self.grid[i]])
