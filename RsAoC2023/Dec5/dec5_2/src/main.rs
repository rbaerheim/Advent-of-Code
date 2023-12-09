use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;
use rayon::prelude::*;

fn main() {
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
        let mut brute_seed: i64 = 0;
        for (i, seed) in seeds.iter_mut().enumerate() {
            if i % 2 == 0 {
                brute_seed = *seed;
                continue;
            }
            let result = (brute_seed..(*seed + brute_seed))
                .into_par_iter()
                .fold(|| i64::MAX, |min, mut current| {
                    let mut new_map = false;
                    for map in &mappers {
                        if map[0] == -1 {
                            new_map = false;
                        }
                        if (map[1]..map[1] + map[2]).contains(&current) && !new_map {
                            current += map[0] - map[1];
                            new_map = true;
                        }
                    }
                    std::cmp::min(min, current)
                })
                .reduce(|| i64::MAX, |a, b| std::cmp::min(a, b));
            println!("Result: {:?}", result) // 77435348
        }
    }
}

fn read_input_lines<P>(filename: P) -> io::Result<io::Lines<io::BufReader<File>>>
    where P: AsRef<Path>, {
    let file = File::open(filename)?;
    Ok(io::BufReader::new(file).lines())
}
