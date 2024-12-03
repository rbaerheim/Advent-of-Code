import re

solution = 0

# Read the content of the file
with open("input.txt", "r") as file:
    text = file.read()

# Regular expression to match 'mul(number,number)'
pattern = r"mul\((\d+),(\d+)\)"

# Find all matches and convert them into tuples of integers
matches = re.findall(pattern, text)
for x, y in matches:
    solution += int(x) * int(y)

print(solution)