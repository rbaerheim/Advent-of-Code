solution = 0
input_array = []
first_iter = True
word_to_find = "MAS"

with open('input.txt', 'r', encoding='utf-8-sig') as file:
    for line in file:
        if first_iter:
            input_array.append("0" * (len(line) + 1))
            first_iter = False
        input_array.append("0" + line.strip() + "0")
    input_array.append("0" * (len(line) + 2))

    for i in range(1, len(input_array) - 1):
        for j in range(1, len(input_array[i]) - 1):
            if (input_array[i - 1][j - 1] + input_array[i][j] + input_array[i + 1][j + 1]) == word_to_find or (input_array[i - 1][j - 1] + input_array[i][j] + input_array[i + 1][j + 1]) == word_to_find[::-1]:
                if (input_array[i - 1][j + 1] + input_array[i][j] + input_array[i + 1][j - 1]) == word_to_find or (input_array[i - 1][j + 1] + input_array[i][j] + input_array[i + 1][j - 1]) == word_to_find[::-1]:
                    solution += 1

print(solution) # 1990
