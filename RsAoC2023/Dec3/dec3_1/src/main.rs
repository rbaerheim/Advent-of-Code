use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;

fn main() {
    let mut result: i32 = 0;
    let mut i = 0;
    let mut num: String = String::new();
    let mut matrix: Vec<Vec<char>> = Vec::new();
    let mut keep_number: bool = false;
    if let Ok(input) = read_input_lines("input.txt") {
        for line in input {
            if let Ok(ip) = line {
                let char_vec: Vec<char> = ip.chars().collect();
                matrix.push(char_vec);
            }
        }
        let mut row_num = matrix.len();
        let mut col_num = matrix[0].len();

        for row in 0..row_num {
            for col in 0..col_num {
                while matrix[row][col+i].is_numeric() {
                    num.push(matrix[row][col+i]);
                    i = i + 1;
                    if (row > 0 || col > 0 || row < row_num - 1 || col < col_num - 1) {
                        if check_adjacent(matrix[row - 1][col - 1]) {
                            keep_number = true
                        }
                        if check_adjacent(matrix[row - 1][col]) {
                            keep_number = true
                        }
                        if check_adjacent(matrix[row - 1][col + 1]) {
                            keep_number = true
                        }
                        if check_adjacent(matrix[row][col - 1]) {
                            keep_number = true
                        }
                        if check_adjacent(matrix[row][col + 1]) {
                            keep_number = true
                        }
                        if check_adjacent(matrix[row + 1][col - 1]) {
                            keep_number = true
                        }
                        if check_adjacent(matrix[row + 1][col]) {
                            keep_number = true
                        }
                        if check_adjacent(matrix[row - 1][col - 1]) {
                            keep_number = true
                        }
                        if check_adjacent(matrix[row + 1][col + 1]) {
                            keep_number = true
                        }
                    }
                }
                if !num.is_empty() && keep_number {
                    result += num.parse::<i32>().unwrap();
                    num.clear();
                    keep_number = false;
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