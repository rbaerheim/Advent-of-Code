use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;
use std::collections::HashSet;

fn main() {
    let mut result: i32 = 0;
    let base: i32 = 2;
    if let Ok(input) = read_input_lines("input.txt") {
        for line in input {
            if let Ok(ip) = line {
                let cards_split:Vec<&str> = ip.split('|').collect();
                if let Some(winning_number_part) = cards_split.first() {
                    let winning_cards: HashSet<&str> = winning_number_part.split_whitespace().skip(2).collect();
                    let available_cards: HashSet<&str> = cards_split[1].split_whitespace().collect();

                    let same_numbers:HashSet<_> = winning_cards.intersection(&available_cards).collect();
                    if (same_numbers.len() > 0) {
                        result += base.pow((same_numbers.len() - 1) as u32);
                    }
                }
            }
        }
    }
    println!("Result: {}", result) // 24733
}

fn read_input_lines<P>(filename: P) -> io::Result<io::Lines<io::BufReader<File>>>
    where P: AsRef<Path>, {
    let file = File::open(filename)?;
    Ok(io::BufReader::new(file).lines())
}
