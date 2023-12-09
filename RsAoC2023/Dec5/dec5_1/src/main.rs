use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;

fn main() {
    let mut result: i64 = 0;
    let mut seeds: Vec<i64> = Vec::new();
    let mut mappers: Vec<Vec<i64>> = Vec::new();
    if let Ok(input) = read_input_lines("input.txt") {
        for (index, line) in input.enumerate() {
            if let Ok(ip) = line {
                if ip.is_empty() {
                    mappers.push(vec![-1, -1, -1])
                } else if index == 0 {
                    seeds = ip.split_whitespace()
                        .skip(1)
                        .map(|s| s.parse().unwrap())
                        .collect();
                    continue
                } else if ip.chars().all(|c| c.is_numeric() || c.is_whitespace()) {
                    mappers.push(ip.split_whitespace().map(|s| s.parse().unwrap()).to_owned().collect())
                }
            }
        }
        for seed in seeds.iter_mut()
        {
            let mut new_map: bool = false;
            for map in &mappers
            {
                if map[0] == -1 {
                    new_map = false;
                }
                if (map[1]..map[1] + map[2]).contains(seed)  && new_map == false {
                    *seed += map[0] - map[1];
                    new_map = true
                }
            }
        }
    }
    if let Some(min) = seeds.iter().min() {
        result = min.abs();
    } else {
        println!("Error");
    }
    println!("Result: {:?}", result) // 910845529
}

fn read_input_lines<P>(filename: P) -> io::Result<io::Lines<io::BufReader<File>>>
    where P: AsRef<Path>, {
    let file = File::open(filename)?;
    Ok(io::BufReader::new(file).lines())
}
