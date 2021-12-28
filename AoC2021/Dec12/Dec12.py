from collections import deque

with open("input.txt", "r") as input:
    pathList = deque()
    pathDict = {}
    for line in input:
        line = line.strip().split("-")
        pathList.append((line[0], line[1]))
    for paths in pathList:
        pass
        
        
input.close()