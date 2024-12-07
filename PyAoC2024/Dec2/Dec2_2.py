solution = 0
initial_discard_list = []

def check_reaction(numbers_list):
    for j in range(len(numbers_list) - 1):
        if (abs(numbers_list[j] - numbers_list[j + 1]) > 3) or (numbers_list[j] == numbers_list[j + 1]):
            return False
        if j >= 1 and numbers_list[j - 1] > numbers_list[j] < numbers_list[j + 1] or j >= 1 and numbers_list[j - 1] < numbers_list[j] > numbers_list[j + 1]:
            return False
    return True

with open('input.txt', 'r', encoding='utf-8-sig') as file:
    for row in [list(map(int, line.strip().split())) for line in file]:
        if check_reaction(row):
            solution += 1
        else:
            initial_discard_list.append(row)
    for row in initial_discard_list:
        for i, num in enumerate(row):
            without_num = row[:i] + row[i+1:]
            if check_reaction(without_num):
                solution += 1
                break

print(solution) # 520
