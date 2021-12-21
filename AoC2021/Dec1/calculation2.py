from collections import deque

with open("numbers.txt", "r") as numberfile:
    result = 0
    temptotal = 0
    max = 0
    numberlist = deque()
    for number in numberfile:
        number = int(number)
        numberlist.append(number)
        if len(numberlist) == 3:
            for value in numberlist:
                temptotal += value
            if temptotal > max:
                result += 1
            numberlist.popleft()
            max = temptotal
            temptotal = 0
            
numberfile.close()

result -= 1

print(result)