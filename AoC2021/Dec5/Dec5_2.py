import matplotlib.pyplot as plt
import numpy as np

result = 0

def line(x0, y0, x1, y1):
        # Bresenham's line algorithm for finding all points between two points in a coordinate system.
        points_in_line = []
        dx = abs(x1 - x0)
        dy = abs(y1 - y0)
        x, y = x0, y0
        sx = -1 if x0 > x1 else 1
        sy = -1 if y0 > y1 else 1
        if dx > dy:
            err = dx / 2.0
            while x != x1:
                points_in_line.append((x, y))
                err -= dy
                if err < 0:
                    y += sy
                    err += dx
                x += sx
        else:
            err = dy / 2.0
            while y != y1:
                points_in_line.append((x, y))
                err -= dx
                if err < 0:
                    x += sx
                    err += dy
                y += sy
        points_in_line.append((x, y))
        return points_in_line


with open("input.txt", "r") as input:
    intersectList = []
    for numbers in input:
        numbers = numbers.strip().split()
        fromCord = numbers[0]
        toCord = numbers[2]
        fromCord = fromCord.strip().split(",")
        x1 = fromCord[0]
        x1 = int(x1)
        y1 = fromCord[1]
        y1 = int(y1)
        toCord = toCord.strip().split(",")
        x2 = toCord[0]
        x2 = int(x2)
        y2 = toCord[1]
        y2 = int(y2)
        if abs(x2 - x1) != abs(y2 - y1) and x1 != x2 and y1 != y2:
            continue
        pointsCurr = line(x1, y1, x2, y2)
        for item in pointsCurr:
            intersectList.append(item)
input.close()


my_dict = {i:intersectList.count(i) for i in intersectList}

for value in my_dict.values():
    if value > 1:
        result += 1

print(result)

# Only horizaontal and vertical = 5294 intersects
# Horizontal and vertical including 45 degree diagonals = 21698 intersects