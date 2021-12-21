fishDict = {"0":0, "1":0,"2":0,"3":0,"4":0,"5":0,"6":0,"7":0,"8":0}

with open("input.txt", "r") as input:
    for numbers in input:
        numbers = numbers.strip().split(",")
        for i in numbers:
            if i in fishDict:
                fishDict[i] += 1
    for days in range(255):
        if days == 0:
            fishDict["0"] = fishDict["1"]
            fishDict["1"] = fishDict["2"]
            fishDict["2"] = fishDict["3"]
            fishDict["3"] = fishDict["4"]
            fishDict["4"] = fishDict["5"]
            fishDict["5"] = fishDict["6"]
            fishDict["6"] = fishDict["7"]
            fishDict["7"] = fishDict["8"]
            fishDict["8"] = 0
        temp = fishDict["1"]
        fishDict["1"] = fishDict["2"]
        fishDict["2"] = fishDict["3"]
        fishDict["3"] = fishDict["4"]
        fishDict["4"] = fishDict["5"]
        fishDict["5"] = fishDict["6"]
        fishDict["6"] = (fishDict["7"] + fishDict["0"])
        fishDict["7"] = fishDict["8"]
        fishDict["8"] = fishDict["0"]
        fishDict["0"] = temp
        


input.close()

result = 0

for values in fishDict.values():
    result += values

print(fishDict, result)

