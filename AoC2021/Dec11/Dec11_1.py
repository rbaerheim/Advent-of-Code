import numpy as np
from collections import deque

inputs = deque()

with open("input.txt", "r") as input:
    for line in input:
        line=line.strip()
        inputs.append([int(num) for num in line])
    theArray=np.array(inputs)
input.close


class Dumbo:
    def __init__(self, array):
        self.array = array
        self.flashList = deque()
        self.flashCount = 0

    def increaseAllOne(self):
        for r in range(len(self.array)):
            for c in range(len(self.array[r])):
                self.array[r][c] += 1
                if self.array[r][c] == 10:
                    self.flashCount += 1
                    self.flashList.append((r,c))
                    self.array[r][c] = 0

    def checkAdjacent(self):
        while len(self.flashList) > 0:
            coord = self.flashList.pop()

            # Left
            try:
                if coord[1] > 0:
                    if self.array[coord[0]][coord[1] - 1] != 0:
                        self.array[coord[0]][coord[1] - 1] += 1
                    if self.array[coord[0]][coord[1] - 1] == 10:
                        self.flashCount += 1
                        self.flashList.appendleft((coord[0], coord[1] - 1))
                        self.array[coord[0]][coord[1] - 1] = 0
            except IndexError:
                pass

            # Right
            try:
                if self.array[coord[0]][coord[1] + 1] != 0:
                    self.array[coord[0]][coord[1] + 1] += 1
                if self.array[coord[0]][coord[1] + 1] == 10:
                    self.flashCount += 1
                    self.flashList.appendleft((coord[0], coord[1] + 1))
                    self.array[coord[0]][coord[1] + 1] = 0
            except IndexError:
                pass

            # Top
            try:
                if (coord[0] - 1) < 0:
                    pass
                else:
                    if self.array[coord[0] - 1][coord[1]] != 0:
                        self.array[coord[0] - 1][coord[1]] += 1
                    if self.array[coord[0] - 1][coord[1]] == 10:
                        self.flashCount += 1
                        self.flashList.appendleft((coord[0] - 1, coord[1]))
                        self.array[coord[0] - 1][coord[1]] = 0
            except IndexError:
                pass

            # Bottom
            try:
                if (coord[0] + 1) > 9:
                    pass
                else:
                    if self.array[coord[0] + 1][coord[1]] != 0:
                        self.array[coord[0] + 1][coord[1]] += 1
                    if self.array[coord[0] + 1][coord[1]] == 10:
                        self.flashCount += 1
                        self.flashList.appendleft((coord[0] + 1, coord[1]))
                        self.array[coord[0] + 1][coord[1]] = 0
            except IndexError:
                pass

            # Lefttop
            try:
                if (coord[0] - 1) < 0:
                    pass
                else:
                    if coord[1] > 0:
                        if self.array[coord[0] - 1][coord[1] - 1] != 0:
                            self.array[coord[0] - 1][coord[1] - 1] += 1
                        if self.array[coord[0] - 1][coord[1] - 1] == 10:
                            self.flashCount += 1
                            self.flashList.appendleft((coord[0] - 1, coord[1] - 1))
                            self.array[coord[0] - 1][coord[1] - 1] = 0
            except IndexError:
                pass

            # Righttop
            try:
                if (coord[0] - 1) < 0:
                    pass
                else:
                    if self.array[coord[0] - 1][coord[1] + 1] != 0:
                        self.array[coord[0] - 1][coord[1] + 1] += 1
                    if self.array[coord[0] - 1][coord[1] + 1] == 10:
                        self.flashCount += 1
                        self.flashList.appendleft((coord[0] - 1, coord[1] + 1))
                        self.array[coord[0] - 1][coord[1] + 1] = 0
            except IndexError:
                pass

            # Leftbottom
            try:
                if (coord[0] + 1) > 9:
                    pass
                else:
                    if coord[1] > 0:
                        if self.array[coord[0] + 1][coord[1] - 1] != 0:
                            self.array[coord[0] + 1][coord[1] - 1] += 1
                        if self.array[coord[0] + 1][coord[1] - 1] == 10:
                            self.flashCount += 1
                            self.flashList.appendleft((coord[0] + 1, coord[1] - 1))
                            self.array[coord[0] + 1][coord[1] - 1] = 0
            except IndexError:
                pass

            # Rightbottom
            try:
                if (coord[0] + 1) > 9:
                    pass
                else:
                    if self.array[coord[0] + 1][coord[1] + 1] != 0:
                        self.array[coord[0] + 1][coord[1] + 1] += 1
                    if self.array[coord[0] + 1][coord[1] + 1] == 10:
                        self.flashCount += 1
                        self.flashList.appendleft((coord[0] + 1, coord[1] + 1))
                        self.array[coord[0] + 1][coord[1] + 1] = 0
            except IndexError:
                pass
            

    def __repr__(self):
        return f"{self.array}"



if __name__ == "__main__":
    dumbo = Dumbo(theArray)
    for _ in range(100):
        dumbo.increaseAllOne()
        dumbo.checkAdjacent()
    print(f"Part 1: {dumbo.flashCount}")