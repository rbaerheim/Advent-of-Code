import numpy as np

liste = []

result = 0

with open("input.txt", "r") as input:
    for line in input:
        line = line.strip()
        line = list(map(int, line))
        liste.append([line for line in line])
    theArray = np.array(liste)
    for row in range(len(theArray)):
        for column in range(len(theArray[row])):
            if row == 0:
                top = None
            else:
                top = theArray[row - 1][column]
            if row == 99:
                bottom = None
            else:
                bottom = theArray[row + 1][column]
            if column == 0:
                left = None
            else:
                left = theArray[row][column - 1]
            if column == 99:
                right = None
            else:
                right = theArray[row][column + 1]
            if top == None:
                if left == None:
                    if theArray[row][column] < bottom and theArray[row][column] < right:
                        result += theArray[row][column] + 1
                elif right == None:
                    if theArray[row][column] < bottom and theArray[row][column] < left:
                        result += theArray[row][column] + 1
                else:
                    if theArray[row][column] < bottom and theArray[row][column] < left and theArray[row][column] < right:
                        result += theArray[row][column] + 1
                
            elif bottom == None:
                if left == None:
                    if theArray[row][column] < top and theArray[row][column] < right:
                        result += theArray[row][column] + 1
                elif right == None:
                    if theArray[row][column] < top and theArray[row][column] < left:
                        result += theArray[row][column] + 1
                else:
                    if theArray[row][column] < top and theArray[row][column] < left and theArray[row][column] < right:
                        result += theArray[row][column] + 1
            elif left == None:
                if theArray[row][column] < bottom and theArray[row][column] < top and theArray[row][column] < right:
                        result += theArray[row][column] + 1
            elif right == None:
                if theArray[row][column] < bottom and theArray[row][column] < top and theArray[row][column] < left:
                        result += theArray[row][column] + 1
            else:
                if theArray[row][column] < bottom and theArray[row][column] < top and theArray[row][column] < left and theArray[row][column] < right:
                    result += theArray[row][column] + 1
input.close()

print(result)


