use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;

fn main() {
    let mut result: i32 = 0; // 520135
    let mut num: String = String::new();
    let mut matrix: Vec<Vec<char>> = Vec::new();
    let mut keep_number: bool = false;
    if let Ok(input) = read_input_lines("input.txt") {
        for line in input {
            if let Ok(ip) = line {
                let mut char_vec: Vec<char> = ip.chars().collect();
                char_vec.insert(0, '.'); // Add '.' at the beginning
                char_vec.push('.');
                if matrix.is_empty() {
                    matrix.push(vec!['.'; char_vec.len()])
                }
                matrix.push(char_vec.clone());
                if matrix.len() == char_vec.len() - 1 {
                    matrix.push(vec!['.'; char_vec.len()])
                }
            }
        }
        let mut row_num = matrix.len();
        let mut col_num = matrix[0].len();

        for row in 1..row_num - 1 {
            for col in 1..col_num - 1 {
                if matrix[row][col].is_numeric() {
                    num.push(matrix[row][col]);
                    if check_adjacent(matrix[row - 1][col - 1]) {
                        keep_number = true
                    }
                    if check_adjacent(matrix[row + 1][col + 1]) {
                        keep_number = true
                    }
                    if check_adjacent(matrix[row - 1][col + 1]) {
                        keep_number = true
                    }
                    if check_adjacent(matrix[row + 1][col - 1]) {
                        keep_number = true
                    }
                    if check_adjacent(matrix[row - 1][col]) {
                        keep_number = true
                    }
                    if check_adjacent(matrix[row + 1][col]) {
                        keep_number = true
                    }
                    if check_adjacent(matrix[row][col - 1]) {
                        keep_number = true
                    }
                    if check_adjacent(matrix[row][col + 1]) {
                        keep_number = true
                    }
                }
                if !num.is_empty() && keep_number && !matrix[row][col].is_numeric() {
                    let mut number  = num.parse::<i32>();
                    match number {
                        Ok(number) => result += number,
                        Err(e) => println!("Failed to parse number: {}", e),
                    }
                    keep_number = false;
                }
                if !matrix[row][col].is_numeric() {
                    num.clear();
                }
            }
        }
    }
    println!("Result: {}", result) // 2683
}

fn read_input_lines<P>(filename: P) -> io::Result<io::Lines<io::BufReader<File>>>
    where P: AsRef<Path>, {
    let file = File::open(filename)?;
    Ok(io::BufReader::new(file).lines())
}

fn check_adjacent(c: char) -> bool {
    if c != '.' && !c.is_numeric() {
        return true
    }
    false
}