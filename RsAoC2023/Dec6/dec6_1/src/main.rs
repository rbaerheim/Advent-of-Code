use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;

struct Race
{
    race_time: Option<i32>,
    distance_record: Option<i32>,
}



impl Race
{
    fn new() -> Race {
        Race {
            race_time: None,
            distance_record: None,
        }
    }

    fn set_race_time(&mut self, value: i32) {
        self.race_time = Some(value);
    }

    fn set_distance_record(&mut self, value: i32) {
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
    let mut result: i32 = 1;
    let mut races: Vec<Race> = Vec::new();
    let mut inputs: Vec<Vec<i32>> = Vec::new();
    if let Ok(input) = read_input_lines("input.txt") {
        for line in input {
            if let Ok(ip) = line {
                inputs.push(ip.split_whitespace().skip(1).map(|s| s.parse::<i32>().unwrap()).collect())
            }
        }
        for (i, input) in inputs.iter().enumerate()
        {
            if i == 0
            {
                let mut race_one: Race = Race::new();
                race_one.set_race_time(input[0]);
                races.push(race_one);
                let mut race_two: Race = Race::new();
                race_two.set_race_time(input[1]);
                races.push(race_two);
                let mut race_three: Race = Race::new();
                race_three.set_race_time(input[2]);
                races.push(race_three);
                let mut race_four: Race = Race::new();
                race_four.set_race_time(input[3]);
                races.push(race_four);
            } else {
                races[0].set_distance_record(input[0]);
                races[1].set_distance_record(input[1]);
                races[2].set_distance_record(input[2]);
                races[3].set_distance_record(input[3]);
            }
        }

        for (i, race) in races.iter().enumerate()
        {
            let mut num_of_record_beat = 0;
            for ms in 0..race.distance_record.unwrap()
            {
                let time_left = race.race_time.unwrap() - ms;
                let total_distance = ms * time_left;
                if total_distance > race.distance_record.unwrap()
                {
                    num_of_record_beat = num_of_record_beat + 1;
                }
            }
            result = result * num_of_record_beat;
        }
    }
    println!("Result: {}", result) // 3316275
}

fn read_input_lines<P>(filename: P) -> io::Result<io::Lines<io::BufReader<File>>>
    where P: AsRef<Path>, {
    let file = File::open(filename)?;
    Ok(io::BufReader::new(file).lines())
}
