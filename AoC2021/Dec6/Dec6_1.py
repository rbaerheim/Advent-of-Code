import numpy as np

daysLeft = 256

fishnum = 0

with open("input.txt", "r") as input:
    listOfFish = []
    for numbers in input:
        for number in numbers:
            try:
                number = int(number)
            except:
                continue
            listOfFish.append(number)
    fishnum += len(listOfFish)
    while daysLeft > 0:
        for fish in range(len(listOfFish)):
            if listOfFish[fish] > 0:
                listOfFish[fish] -= 1
            elif listOfFish[fish] == 0:
                listOfFish[fish] = 6
                listOfFish.append(8)
                fishnum += 1
        daysLeft -= 1
        print(daysLeft)

input.close()

print(fishnum)

# print(listOfFish)