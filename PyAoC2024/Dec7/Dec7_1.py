solution = 0

def is_test_value(nums, target, index=1, current_value=None):
    if current_value is None:
        current_value = nums[0]
    if index == len(nums):
        return current_value == target
    return (is_test_value(nums, target, index + 1, current_value + nums[index]) or
            is_test_value(nums, target, index + 1, current_value * nums[index]))

with open('input.txt', 'r', encoding='utf-8-sig') as file:
    for line in file:
        line = line.strip()
        test_value, numbers = line.split(':', 1)
        test_value = int(test_value)
        numbers = list(map(int, numbers.split()))
        if is_test_value(numbers, test_value):
            solution += test_value

print(solution) # 3351424677624
