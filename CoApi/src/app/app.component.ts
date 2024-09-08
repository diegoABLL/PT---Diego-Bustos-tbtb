import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  data: any[] = [];
  filteredData: any[] = [];
  currentView = 'table';
  searchQuery = '';

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get('https://jsonplaceholder.typicode.com/users')
      .subscribe((fetchedData: any) => {
        this.data = fetchedData;
        this.filteredData = this.data;
      });
  }

  mostrarTabla() {
    this.currentView = 'table';
  }

  mostrarTarjetas() {
    this.currentView = 'cards';
  }

  filtrarDatos() {
    const query = this.searchQuery.toLowerCase().trim();
    this.filteredData = this.data.filter(user =>
      user.name.toLowerCase().includes(query) ||
      user.email.toLowerCase().includes(query) ||
      user.address.city.toLowerCase().includes(query) ||
      user.username.toLowerCase().includes(query) ||
      user.address.street.toLowerCase().includes(query) ||
      user.address.suite.toLowerCase().includes(query) ||
      user.address.zipcode.toLowerCase().includes(query) ||
      user.phone.toLowerCase().includes(query) ||
      user.website.toLowerCase().includes(query) ||
      user.company.name.toLowerCase().includes(query) ||
      user.company.catchPhrase.toLowerCase().includes(query) ||
      user.company.bs.toLowerCase().includes(query)
    );
  }
}
