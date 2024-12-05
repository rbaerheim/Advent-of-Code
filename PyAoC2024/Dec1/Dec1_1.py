with open("input.txt") as file:
    data = [list(map(int, line.strip().split())) for line in file]

left, right = zip(*data)
left, right = sorted(left), sorted(right)

solution = sum(abs(left - right) for left, right in zip(left, right))

print(solution) # 2113135
