from collections import Counter

with open("input.txt") as file:
    data = [list(map(int, line.strip().split())) for line in file]

left, right = zip(*data)
right_counts = Counter(right)

solution = sum(num * right_counts[num] for num in left)

print(solution) # 19097157