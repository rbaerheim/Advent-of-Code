use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;
use std::str;

fn main() {
    let mut result: i32 = 0;
    if let Ok(input) = read_input_lines("input.txt") {
        for line in input {
            if let Ok(ip) = line {
                let number = combine_first_and_last_digit(ip.as_str());
                result+=number;
            }
        }
    }
    println!("Result: {}", result) // 54561
}

fn read_input_lines<P>(filename: P) -> io::Result<io::Lines<io::BufReader<File>>>
    where P: AsRef<Path>, {
    let file = File::open(filename)?;
    Ok(io::BufReader::new(file).lines())
}

fn combine_first_and_last_digit(line: &str) -> i32 {
    let id = line
        .trim()
        .chars()
        .filter(|c| c.is_numeric())
        .collect::<String>();

    let first_char = id.chars().next().unwrap_or_default();
    let last_char = id.chars().last().unwrap_or(first_char);

    format!("{}{}", first_char, last_char).parse::<i32>().unwrap()
}
