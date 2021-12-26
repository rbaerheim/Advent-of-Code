import numpy as np

inputs = []

with open("input.txt", "r") as input:
    for line in input:
        line=line.strip()
        inputs.append([int(num) for num in line])
    theArray=np.array(inputs)
input.close


class Dumbo:
    def __init__(self, array):
        self.array = array
        self.flashList = []

    def increase(self):
        for r in range(len(self.array)):
            for c in range(len(self.array[r])):
                self.array[r][c] += 2
                if self.array[r][c] == 10:
                    self.flashList.append((r,c))
                    self.array[r][c] = 0

    def checkAdjacent(self):
        pass

    def __repr__(self):
        return f"{self.array}"



if __name__ == "__main__":
    dumbo = Dumbo(theArray)
    print(dumbo)
    dumbo.increase()
    print(dumbo)
    print(dumbo.flashList)