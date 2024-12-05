import re

solution = 0

with open("input.txt", "r") as file:
    text = file.read()

pattern = r"mul\((\d+),(\d+)\)"

matches = re.findall(pattern, text)
for x, y in matches:
    solution += int(x) * int(y)

print(solution) # 188116424