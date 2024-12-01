from collections import Counter

with open("input.txt") as file:
    data = [list(map(int, line.strip().split())) for line in file]

left, right = zip(*data)
right_counts = Counter(right)

print(sum(num * right_counts[num] for num in left))
# 19097157