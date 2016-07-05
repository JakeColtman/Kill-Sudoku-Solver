from Sudoku import Sudoku


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

    def solve(self):
        counter = 0
        while not self.validate():
            self.reset()
            try:
                self.sudoku.generate_new_values()
            except:
                pass
            counter += 1
            if counter % 1000 == 0:
                print(counter)
        self.print()
        return self.sudoku.grid

    def validate(self):

        if not self.sudoku.validate():
            return False
        for pos_list, value in self.constraints:
            sum = 0
            for pos in pos_list:
                sum += self.sudoku.grid[pos[0]][pos[1]].possible_values[0]
            if sum != value:
                return False
        return True

    def reset(self):
        self.sudoku.reset()

    def print(self):
        self.sudoku.print()


ks = KillerSudoku()
ks.add_constraint([[[0,0],[0,1], [1,1]], 13])
ks.add_constraint([[[1,0],[2,0]], 8])
ks.add_constraint([[[0,2],[0,3]], 7])
ks.add_constraint([[[1,2],[1,3]], 12])
ks.solve()
