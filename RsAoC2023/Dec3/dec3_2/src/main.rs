use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;

fn main() {
    let mut result: i32 = 0;
    let mut matrix: Vec<Vec<char>> = Vec::new();
    if let Ok(input) = read_input_lines("input.txt") {
        for line in input {
            if let Ok(ip) = line {
                let mut char_vec: Vec<char> = ip.chars().collect();
                char_vec.insert(0, '.');
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
        let row_num = matrix.len();
        let col_num = matrix[0].len();

        for row in 1..row_num - 1 {
            for col in 1..col_num - 1 {
                if matrix[row][col] == '*' {
                    let indexes:Vec<String> = get_number_indexes(&matrix, row, col);
                    if indexes.len() == 2 {
                        result += indexes[0].parse::<i32>().unwrap() * indexes[1].parse::<i32>().unwrap()
                    }
                }
            }
        }
    }
    println!("Result: {}", result) // 72514855
}

fn read_input_lines<P>(filename: P) -> io::Result<io::Lines<io::BufReader<File>>>
    where P: AsRef<Path>, {
    let file = File::open(filename)?;
    Ok(io::BufReader::new(file).lines())
}

fn get_number_indexes(matrix_2d: &Vec<Vec<char>>, row: usize, col: usize) -> Vec<String> {
    let mut coordinates:Vec<(usize, usize)> = Vec::new();
    let mut numbers:Vec<String> = Vec::new();
    let mut iterator: usize = 0;
    let mut checked_indexes:Vec<(usize, usize)> = Vec::new();

    if matrix_2d[row - 1][col].is_numeric() {
        coordinates.push((row - 1, col));
    }
    if matrix_2d[row + 1][col].is_numeric() {
        coordinates.push((row + 1, col));
    }
    if matrix_2d[row][col - 1].is_numeric() {
        coordinates.push((row, col - 1));
    }
    if matrix_2d[row][col + 1].is_numeric() {
        coordinates.push((row, col + 1));
    }
    if matrix_2d[row - 1][col - 1].is_numeric() {
        coordinates.push((row - 1, col - 1));
    }
    if matrix_2d[row + 1][col - 1].is_numeric() {
        coordinates.push((row + 1, col - 1));
    }
    if matrix_2d[row - 1][col + 1].is_numeric() {
        coordinates.push((row - 1, col + 1));
    }
    if matrix_2d[row + 1][col + 1].is_numeric() {
        coordinates.push((row + 1, col + 1));
    }

    for coordinate in coordinates {
        let mut num_dupe:bool = false;
        let mut number:String = String::new();
        while matrix_2d[coordinate.0][coordinate.1 - iterator].is_numeric() {
            if checked_indexes.iter().any(|&i| i == (coordinate.0, coordinate.1 - iterator)) {
                num_dupe = true;
                break
            }
            number.insert(0,matrix_2d[coordinate.0][coordinate.1 - iterator]);
            checked_indexes.push((coordinate.0, coordinate.1 - iterator));
            iterator = iterator + 1;
        }
        iterator = 1;
        while matrix_2d[coordinate.0][coordinate.1 + iterator].is_numeric() {
            if checked_indexes.iter().any(|&i| i == (coordinate.0, coordinate.1 + iterator)) {
                num_dupe = true;
                break
            }
            number.push(matrix_2d[coordinate.0][coordinate.1 + iterator]);
            checked_indexes.push((coordinate.0, coordinate.1 + iterator));
            iterator = iterator + 1;
        }
        iterator = 0;
        if !num_dupe {
            numbers.push(number);
        }
    }
        return numbers
}