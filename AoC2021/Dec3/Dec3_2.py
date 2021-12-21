with open("input.txt", "r") as file:
    result2 = []
    numberlist = []
    n = 0
    zeroes, ones = 0, 0
    for numbers in file:
        numbers = numbers.strip()
        numberlist.append(numbers)
    while True:
        for number in numberlist:
            if len(number) == 12:
                if number[n] == "1":
                    ones += 1
                else:
                    zeroes += 1
        if ones < zeroes:
            for numberes in numberlist:
                if numberes[n] == "0":
                    result2.append(numberes)
        elif zeroes < ones:
            for numberes in numberlist:
                if numberes[n] == "1":
                    result2.append(numberes)
        else:
            for numberes in numberlist:
                if numberes[n] == "1":
                    result2.append(numberes)
        if len(result2) == 1:
            break
        numberlist.clear()
        for numbers in result2:
            numberlist.append(numbers)
        result2.clear()
        n += 1
        ones, zeroes = 0, 0
file.close()

with open("input.txt", "r") as file:
    result3 = []
    numberlist = []
    n = 0
    zeroes, ones = 0, 0
    for numbers in file:
        numbers = numbers.strip()
        numberlist.append(numbers)
    while True:
        for number in numberlist:
            if len(number) == 12:
                if number[n] == "1":
                    ones += 1
                else:
                    zeroes += 1
        if ones > zeroes:
            for numberes in numberlist:
                if numberes[n] == "0":
                    result3.append(numberes)
        elif zeroes > ones:
            for numberes in numberlist:
                if numberes[n] == "1":
                    result3.append(numberes)
        else:
            for numberes in numberlist:
                if numberes[n] == "0":
                    result3.append(numberes)
        if len(result3) == 1:
            break
        numberlist.clear()
        for numbers in result3:
            numberlist.append(numbers)
        result3.clear()
        n += 1
        ones, zeroes = 0, 0
file.close()

result1 = int(result3[0], 2)

result2 = int(result2[0], 2)

print(result1 * result2)
