use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;
use std::collections::{HashMap, HashSet};

fn main() {
    let mut result: i32 = 0;
    let mut a_vec: Vec<String> = Vec::new();
    let mut dict: HashMap<usize, i32> = HashMap::new();
    if let Ok(input) = read_input_lines("input.txt") {
        for line in input {
            if let Ok(ip) = line {
                a_vec.push(ip.clone());
            }
        }
        for (i, line) in a_vec.iter().enumerate() {

            dict.entry(i)
                .and_modify(|e| *e += 1)
                .or_insert(1);

            let cards_split: Vec<_> = line.split('|').map(|s| s.to_string()).collect();
            let winning_cards: HashSet<String> = cards_split[0].split_whitespace().skip(2).map(|s| s.to_string()).collect();
            let available_cards: HashSet<String> = cards_split[1].split_whitespace().map(|s| s.to_string()).collect();

            let intersect: HashSet<&String> = winning_cards.intersection(&available_cards).collect();

            for j in 0..intersect.len() {
                if let Some(&value) = dict.get(&i) {
                    dict.entry(i + 1 + j)
                        .and_modify(|e| *e += value)
                        .or_insert(value);
                }
            }
        }
        result = dict.values().sum();
    }
    println!("Result: {}", result); // 5422730
}

fn read_input_lines<P>(filename: P) -> io::Result<io::Lines<io::BufReader<File>>>
    where P: AsRef<Path>, {
    let file = File::open(filename)?;
    Ok(io::BufReader::new(file).lines())
}
