import re

solution = 0

with open("input.txt", "r") as file:
    text = file.read()

mul_enabled = True
match_tuples = []

matches = re.finditer(rf"{r"do\(\)"}|{r"don't\(\)"}|{r"mul\((\d+),(\d+)\)"}", text)

for match in matches:
    if match.group(0) == "do()":
        mul_enabled = True
    elif match.group(0) == "don't()":
        mul_enabled = False
    else:
        if mul_enabled:
            x, y = map(int, match.groups())
            match_tuples.append((x, y))

for x, y in match_tuples:
    solution += x * y

print(solution) # 104245808