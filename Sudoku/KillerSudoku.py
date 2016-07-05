from Sudoku import Sudoku
from random import choice


class KillerSudoku:
    def __init__(self, sudoku: Sudoku = None):
        if sudoku is None:
            sudoku = Sudoku()
        self.sudoku = sudoku
        self.constraints = []

    def add_constraint(self, constraint):
        '''
            Constraint is a tuplie of coordinate list, total value
            e.g.
            [[[0,0], [0,1]], 4]
        '''
        self.constraints.append(constraint)

    def generate_new_values(self):
        self.sudoku.generate_new_values()
        for pos_list, value in self.constraints:
            for index, (i, j) in enumerate(pos_list):
                possible_values = [x for x in self.sudoku.grid[i][j].possible_values if x <= value]
                if index + 1 == len(pos_list):
                    if value not in pos_list:
                        raise Exception()
                    chosen = value
                else:
                    chosen = choice(possible_values)
                value -= chosen
                self.sudoku.set_value(i, j, chosen)

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
        return self.sudoku.grid

    def validate(self):
        for pos_list, value in self.constraints:
            sum = 0
            for pos in pos_list:
                try:
                    sum += self.sudoku.grid[pos[0]][pos[1]].possible_values[0]
                except:
                    print(pos)
            if sum != value:
                return False
        if not self.sudoku.validate():
            return False
        return True

    def reset(self):
        self.sudoku.reset()

    def print(self):
        self.sudoku.print()


ks = KillerSudoku()
ks.add_constraint([[[0, 0], [0, 1], [1, 1]], 13])
ks.add_constraint([[[1, 0], [2, 0]], 8])
ks.add_constraint([[[0, 2], [0, 3]], 7])
ks.add_constraint([[[1, 2], [1, 3]], 12])
ks.add_constraint([[[2, 2], [3, 2]], 8])
ks.add_constraint([[[2, 3], [3, 3]], 10])

ks.add_constraint([[[2, 1], [3, 1], [4, 1]], 14])
ks.add_constraint([[[3, 0], [4, 0]], 14])
ks.add_constraint([[[5, 0], [6, 0]], 10])
ks.add_constraint([[[5, 1], [6, 1]], 12])
ks.add_constraint([[[5, 2], [6, 2]], 12])
ks.add_constraint([[[7, 0], [7, 1]], 9])
ks.add_constraint([[[8, 0], [8, 1]], 10])

ks.add_constraint([[[7, 2], [8, 2]], 8])

ks.add_constraint([[[4, 2], [4, 3], [5, 3]], 18])

ks.add_constraint([[[8, 3], [7, 3], [8, 4], [7, 4]], 25])

ks.solve()
