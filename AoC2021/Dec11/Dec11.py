import numpy as np

inputs = []

flashNum = 0

with open("input.txt", "r") as input:
    for line in input:
        line=line.strip()
        inputs.append([int(num) for num in line])
    theArray=np.array(inputs)
    print(theArray)
    for _ in range(2):
        for r in range(len(theArray)):
            for c in range(len(theArray[r])):
                theArray[r][c]+=1
                moreFlash = False
                while not moreFlash:
                    if theArray[r][c]==10:
                        theArray[r][c]=0
                        flashNum+=1
                        if theArray[r-1][c-1]==10:
                            if r<0 or c<0:
                                continue
                            


input.close()

print(theArray)