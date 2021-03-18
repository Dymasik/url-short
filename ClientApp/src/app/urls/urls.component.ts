import { HttpClient } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetUrlsResponse } from '../responses/get-urls-response';
import { Url } from '../url';

@Component({
  selector: 'app-urls',
  templateUrl: './urls.component.html',
  styleUrls: ['./urls.component.css']
})
export class UrlsComponent implements OnInit, OnDestroy {
  private subscription: Subscription;

  urls: Url[] = [];
  errorMessage: string = '';

  constructor(private httpClient: HttpClient) { }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  ngOnInit() {
    this.subscription = this.httpClient.get<GetUrlsResponse>('/api/url')
      .subscribe(response => {
        if (response.Success) {
          this.urls = response.Urls;
        } else {
          this.errorMessage = response.ErrorMessage;
        }
      });
  }

}
