def Task1():
    s=input('Введите ленту: ')
    i = int(input('Введите начало в ленте: '))
    

def Task2():
    s=input('Введите ленту: ')
    i=int(input('Введите начало в ленте: '))
    def q1(index,string):
        if string[index]=='l':
            q1(index-1,string)
        else:
            string=string[0:index]+'l'+string[index+1:]
            q2(index+1,string)
    def q2(index,string):
        if string[index]=='l':
            q2(index+1,string)
        else:
            string=string[0:index]+'l'+string[index+1:]
            q3(index+1,string)
    def q3(index,string):
        if string[index]=='l':
            print(string)
            return 0
        else:
            string=string[0:index]+'l'+string[index+1:]
            q4(index,string)
    def q4(index,string):
        if string[index]=='l':
            q4(index-1,string)
        else:
            string=string[0:index]+'l'+string[index+1:]
            q5(index-1,string)
    def q5(index,string):
        if string[index]=='l':
            print(string)
            return 0
        else:
            q3(index+1,string)
    q1(i,s)
Task2()





