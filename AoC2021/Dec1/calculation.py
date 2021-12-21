with open("numbers.txt", "r") as numberfile:
    results = 0
    maxnumber = 0
    for number in numberfile:
        number = int(number)
        if number > maxnumber:
            results += 1
        maxnumber = number
numberfile.close()
results -= 1
print(results)

