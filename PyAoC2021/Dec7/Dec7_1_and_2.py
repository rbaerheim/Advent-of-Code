import statistics
import math

toDepth = 0

totalFuelSpentpart1 = 0
totalFuelSpentpart2 = 0

with open("input.txt", "r") as input:
    for numbers in input:
        numbers = numbers.strip().split(",")
    numbers = [int(i) for i in numbers]
    theMedian = round(statistics.median(numbers))
    theMean = math.floor(statistics.mean(numbers))
    for depths in numbers:
        totalFuelSpentpart1 += abs(depths - theMedian)
    distances = [abs(depths - theMean) for depths in numbers]
    fuels = [d*(d + 1)/2 for d in distances]
    totalFuelSpentpart2 = round(sum(fuels))
    

input.close()

print(f"Part 1: {totalFuelSpentpart1} Part 2: {totalFuelSpentpart2}")