import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import {MatToolbar} from '@angular/material/toolbar';
import { DropContainerComponent } from './components/drop-container/drop-container.component';
import {NgxFileDropModule} from 'ngx-file-drop';
import {MatButton} from "@angular/material/button";

@NgModule({
  declarations: [
    AppComponent,
    DropContainerComponent
  ],
    imports: [
        BrowserModule, HttpClientModule,
        AppRoutingModule, MatToolbar,
        NgxFileDropModule, MatButton
    ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
