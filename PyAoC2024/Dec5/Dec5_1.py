rules = []
isRules = True
solution = 0

with open('input.txt', 'r', encoding='utf-8-sig') as file:
    for line in file:
        if line.isspace():
            isRules = False
            continue
        if isRules:
            X, Y = line.strip().split('|')
            rules.append((X, Y))
        else:
            page = line.strip().split(',')
            rules_applied = []
            for (X, Y) in rules:
                if X in page and Y in page:
                    rules_applied.append((X, Y))

            correct = True
            for (X, Y) in rules_applied:
                if page.index(X) > page.index(Y):
                    correct = False
                    break

            if correct:
                solution += int(page[len(page) // 2])

print(solution) #4996