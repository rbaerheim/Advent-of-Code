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

print(result3)