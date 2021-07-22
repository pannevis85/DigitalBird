import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule} from '@angular/forms'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { PartnerListComponent } from './partners/partner-list/partner-list.component';
import { PartnerDetailComponent } from './partners/partner-detail/partner-detail.component';
import { VendorDetailComponent } from './vendors/vendor-detail/vendor-detail.component';
import { VendorListComponent } from './vendors/vendor-list/vendor-list.component';
import { SharedModule } from './_modules/shared.module';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { PartnerEditComponent } from './partners/partner-edit/partner-edit.component';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,    
    PartnerListComponent,
    PartnerDetailComponent,
    VendorDetailComponent,
    VendorListComponent,
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent,
    UserEditComponent,
    PartnerEditComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    SharedModule,
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
