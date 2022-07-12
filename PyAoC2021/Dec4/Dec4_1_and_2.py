from collections import deque
import numpy as np

lists = deque()
turn = 0
board = 0

with open("input.txt", "r") as input:
    bingonumbers = input.readline()
    bingonumbers = bingonumbers.strip().split(",")
    for numbers in input:
        temp = 0
        numbers = numbers.strip().split()
        if len(numbers) == 0:
            continue
        lists.append(numbers)
        if len(lists) == 5:
            array = np.array(lists)
            array = array.astype(np.int)
            board += 1
            for num in bingonumbers:
                num = int(num)
                continuing = True
                temp += 1
                array = np.where(array[:] == num, 0, array)
                for i in range (5):
                    row_zeros = np.count_nonzero(array[i:,])
                    col_zeros = np.count_nonzero(array[:,i])
                    if not row_zeros or not  col_zeros:
                        if temp > turn:
                            turn = temp
                            print(num, turn)
                            print(array)
                        continuing = False
                        break
                if not continuing:
                    break
            lists.clear()
input.close()

# print(lists)
# print(array)