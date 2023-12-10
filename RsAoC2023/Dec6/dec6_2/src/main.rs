use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;
use rayon::prelude::*;

struct Race
{
    race_time: Option<i128>,
    distance_record: Option<i128>,
}



impl Race
{
    fn new() -> Race {
        Race {
            race_time: None,
            distance_record: None,
        }
    }

    fn set_race_time(&mut self, value: i128) {
        self.race_time = Some(value);
    }

    fn set_distance_record(&mut self, value: i128) {
        self.distance_record = Some(value);
    }

    fn display(&self) {
        if let Some(field1) = &self.race_time {
            println!("race_time: {}", field1);
        }
        if let Some(field2) = &self.distance_record {
            println!("distance_record: {}", field2);
        }
    }
}

fn main() {
    let mut result: i128 = 1;
    let mut races: Vec<Race> = Vec::new();
    let mut inputs: Vec<Vec<i128>> = Vec::new();
    if let Ok(input) = read_input_lines("input.txt") {
        for line in input {
            if let Ok(ip) = line {
                let combined_number: Vec<i128> = ip.trim().replace(" ", "").split(':').skip(1).map(|s| s.parse().unwrap()).collect();
                inputs.push(combined_number)
            }
        }
        for (i, input) in inputs.iter().enumerate()
        {
            if i == 0
            {
                let mut race_one: Race = Race::new();
                race_one.set_race_time(input[0]);
                races.push(race_one);
            } else {
                races[0].set_distance_record(input[0]);
            }
        }

        let results: Vec<_> = races
            .par_iter() // Convert to parallel iterator
            .enumerate()
            .map(|(i, race)| {
                let mut num_of_record_beat = 0;
                for ms in 0..race.distance_record.unwrap() {
                    let time_left = race.race_time.unwrap() - ms;
                    let total_distance = ms * time_left;
                    if total_distance > race.distance_record.unwrap() {
                        num_of_record_beat += 1;
                    }
                }
                num_of_record_beat // Return the result for each race
            })
            .collect();
        println!("Result: {:?}", results) // 24733
    }
}

fn read_input_lines<P>(filename: P) -> io::Result<io::Lines<io::BufReader<File>>>
    where P: AsRef<Path>, {
    let file = File::open(filename)?;
    Ok(io::BufReader::new(file).lines())
}
