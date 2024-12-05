import re

solution = 0
input_array = []
columns = []
all_strings = []

with open('input.txt', 'r', encoding='utf-8-sig') as file:
    for line in file:
        input_array.append(line.strip())

    rows = len(input_array)
    cols = len(input_array[0])

    for i, text in enumerate(input_array):
        for j, letter in enumerate(text):
            if i == 0:
                columns.append(letter)
            else:
                columns[j] += letter
    for column in columns:
        input_array.append(column)

    for d in range(rows + cols - 1):
        diagonal = []
        for row in range(rows):
            col = d - row
            if 0 <= col < cols:
                diagonal.append(input_array[row][col])
        if diagonal:
            input_array.append(''.join(diagonal))

    for d in range(rows + cols - 1):
        diagonal = []
        for row in range(rows):
            col = d - (rows - row - 1)
            if 0 <= col < cols:
                diagonal.append(input_array[row][col])
        if diagonal:
            input_array.append(''.join(diagonal))

    for lines in input_array:
        all_strings.append(lines)
        all_strings.append(lines[::-1])

    for xmas in all_strings:
        solution += len([match.start() for match in re.finditer(rf'{"XMAS"}', xmas)])

print(solution) # 2654