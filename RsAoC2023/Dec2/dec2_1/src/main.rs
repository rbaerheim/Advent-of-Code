use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;
use std::collections::HashMap;

struct Colors {

}

impl Colors {
    const MAX_RED: i32 = 12;
    const MAX_GREEN: i32 = 13;
    const MAX_BLUE: i32 = 14;
}

fn main() {
    let mut result: i32 = 0;
    if let Ok(input) = read_input_lines("input.txt") {
        for line in input {
            if let Ok(ip) = line {
                result += get_valid_game_id(ip);
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

fn get_valid_game_id(line: String) -> i32 {
    let mut game_id: i32 = 0;
    let game_sets: Vec<&str> = line.trim().split(|c| c == ':' || c == ';').collect();
    if let Some(first_string) = game_sets.get(0) {
        let parts: Vec<&str> = first_string.split_whitespace().collect();
        let number_str = parts[1].parse::<i32>().unwrap();
        game_id = number_str;
    }

    let mut map = HashMap::new();

    for c in game_sets.iter().skip(1) {
        let game_set: Vec<&str> = c.split(|c| c == ',').map(|s| s.trim()).collect();
        for b in game_set {
            let parts: Vec<&str> = b.split_whitespace().collect();
            if parts.len() == 2 {
                let value = parts[0].trim().parse::<i32>().unwrap();
                let key = parts[1].trim();
                map.insert(key, value);
            }
            for (key, value) in &map {
                match key {
                    &"red" => if value > &Colors::MAX_RED {
                        return 0;
                    }
                    &"green" => if value > &Colors::MAX_GREEN {
                        return 0;
                    }
                    &"blue" => if value > &Colors::MAX_BLUE {
                        return 0;
                    }
                    _ => println!("No color match"),
                }
            }
        }
    }

    return game_id;
}