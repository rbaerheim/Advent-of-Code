solution = 0

with open('input.txt', 'r', encoding='utf-8-sig') as file:
    for row in [list(map(int, line.strip().split())) for line in file]:
        good = True
        for i in range(len(row) - 1):
            if (abs(row[i] - row[i + 1]) > 3) or (row[i] == row[i + 1]):
                good = False
                break
            if i >= 1 and row[i - 1] > row[i] < row[i + 1] or i >= 1 and row[i - 1] < row[i] > row[i + 1]:
                good = False
                break
        if good:
            solution += 1


print(solution) # 472
