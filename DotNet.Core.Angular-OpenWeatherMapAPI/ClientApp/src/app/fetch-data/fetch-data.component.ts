import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public weather: CurrentWeather | undefined;
  public apiKey: string = '';
  public enteredCity: string = '';
  public dataType: string = '';
  public resError: string = '';

  constructor(private httpClient: HttpClient) {

  };

  public getCurrentWeather(apiKey: string, enteredCity: string, dataType: string) {

    this.httpClient.get<CurrentWeather>('currentweather/GetWeather/' + apiKey + '/' + enteredCity + '/' + dataType).subscribe(result => {
      this.weather = result;
      console.log(this.weather)
      this.resError = '';
    }, error => {
      console.error(error); this.resError = error.statusText; this.weather = undefined;
    });
  };
};

interface CurrentWeather {
  date: Date;
  countryName: string;
  cityName: string;
  main: string;
  description: string;
  temp: number;
};
