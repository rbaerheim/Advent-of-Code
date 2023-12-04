use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;

fn main() {
    let mut result: i32 = 0; // 71770908 to low , 512519057 68313164
    let mut num1: String = String::new();
    let mut num2: String = String::new();
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
                    let indexes:Vec<(usize, usize)> = get_number_indexes(&matrix, row, col);
                    if indexes.len() == 2
                    {
                        num1.push(matrix[indexes[0].0][indexes[0].1]);
                        if matrix[indexes[0].0][(indexes[0].1) - 1].is_numeric() {
                            num1.insert(0,matrix[indexes[0].0][(indexes[0].1) - 1]);
                            if matrix[indexes[0].0][(indexes[0].1) - 2].is_numeric() {
                                num1.insert(0, matrix[indexes[0].0][(indexes[0].1) - 2]);
                            }
                        }

                        // if matrix[indexes[0].0][(indexes[0].1) - 2].is_numeric() {
                        //     num1.insert(0, matrix[indexes[0].0][(indexes[0].1) - 2]);
                        // }

                        if matrix[indexes[0].0][(indexes[0].1) + 1].is_numeric() {
                            num1.push(matrix[indexes[0].0][(indexes[0].1) + 1]);
                            if matrix[indexes[0].0][(indexes[0].1) + 2].is_numeric() {
                                num1.push(matrix[indexes[0].0][(indexes[0].1) + 2]);

                            }
                        }

                        // if matrix[indexes[0].0][(indexes[0].1) + 2].is_numeric() {
                        //     num1.push(matrix[indexes[0].0][(indexes[0].1) + 2]);
                        //
                        // }
                        num2.push(matrix[indexes[1].0][indexes[1].1]);
                        if matrix[indexes[1].0][(indexes[1].1) - 1].is_numeric() {
                            num2.insert(0,matrix[indexes[1].0][(indexes[1].1) - 1]);
                            if matrix[indexes[1].0][(indexes[1].1) - 2].is_numeric() {
                                num2.insert(0, matrix[indexes[1].0][(indexes[1].1) - 2]);
                            }
                        }

                        // if matrix[indexes[1].0][(indexes[1].1) - 2].is_numeric() {
                        //     num2.insert(0, matrix[indexes[1].0][(indexes[1].1) - 2]);
                        // }

                        if matrix[indexes[1].0][(indexes[1].1) + 1].is_numeric() {
                            num2.push(matrix[indexes[1].0][(indexes[1].1) + 1]);
                            if matrix[indexes[1].0][(indexes[1].1) + 2].is_numeric() {
                                num2.push(matrix[indexes[1].0][(indexes[1].1) + 2]);
                            }
                        }

                        // if matrix[indexes[1].0][(indexes[1].1) + 2].is_numeric() {
                        //     num2.push(matrix[indexes[1].0][(indexes[1].1) + 2]);
                        // }

                        result += (num1.parse::<i32>().unwrap() * num2.parse::<i32>().unwrap());
                        num1.clear();
                        num2.clear()
                    }
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

fn get_number_indexes(matrix_2d: &Vec<Vec<char>>, row: usize, col: usize) -> Vec<(usize, usize)> {
    let mut coordinates:Vec<(usize, usize)> = Vec::new();
    let mut north: bool = false;
    let mut south: bool = false;
    let mut west: bool = false;
    let mut east: bool = false;
    if matrix_2d[row - 1][col].is_numeric() && coordinates.len() < 2 && !north {
        coordinates.push((row - 1, col));
        north = !north
    }
    if matrix_2d[row + 1][col].is_numeric() && coordinates.len() < 2 && !south {
        coordinates.push((row + 1, col));
        south = !south
    }
    if matrix_2d[row][col - 1].is_numeric() && coordinates.len() < 2 && !west {
        coordinates.push((row, col - 1));
        west = !west
    }
    if matrix_2d[row][col + 1].is_numeric() && coordinates.len() < 2 && !east {
        coordinates.push((row, col + 1));
        east = !east
    }
    if matrix_2d[row - 1][col - 1].is_numeric() && coordinates.len() < 2 && !north {
        coordinates.push((row - 1, col - 1));
        north = !north
    }
    if matrix_2d[row + 1][col - 1].is_numeric() && coordinates.len() < 2 && !south {
        coordinates.push((row + 1, col - 1));
        south = !south
    }
    if matrix_2d[row - 1][col + 1].is_numeric() && coordinates.len() < 2 && !north{
        coordinates.push((row - 1, col + 1));
        north = !north
    }
    if matrix_2d[row + 1][col + 1].is_numeric() && coordinates.len() < 2 && !south{
        coordinates.push((row + 1, col + 1));
        south = !south
    }

    return coordinates
}