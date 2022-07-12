import statistics

corrupt = []

inComplete = []

result = 0

scoreList = []

with open("input.txt", "r") as input:
    for line in input:
        line = line.strip()
        corrupted = False
        corrupt.clear()
        for char in line:
            if char == "(":
                corrupt.append(char)
            elif char == "[":
                corrupt.append(char)
            elif char == "{":
                corrupt.append(char)
            elif char == "<":
                corrupt.append(char)
            elif char == ")":
                if corrupt[-1] == "(":
                    corrupt.pop()
                    continue
                else:
                    result += 3
                    corrupted = True
                    break
            elif char == "]":
                if corrupt[-1] == "[":
                    corrupt.pop()
                    continue
                else:
                    result += 57
                    corrupted = True
                    break
            elif char == "}":
                if corrupt[-1] == "{":
                    corrupt.pop()
                    continue
                else:
                    result += 1197
                    corrupted = True
                    break
            elif char == ">":
                if corrupt[-1] == "<":
                    corrupt.pop()
                    continue
                else:
                    result += 25137
                    corrupted = True
                    break
        if corrupted == False:
            inComplete.append([i for i in corrupt])
    for lines in inComplete:
        score = 0
        for i in range(len(lines) - 1, -1, -1):
            if lines[i] == "(":
                point = 1
            elif lines[i] == "[":
                point = 2
            elif lines[i] == "{":
                point = 3
            elif lines[i] == "<":
                point = 4
            score = (5 * score) + point
        scoreList.append(score)
input.close()

print(f"Part 2: {statistics.median(scoreList)}")

print(f"Part 1: {result}")