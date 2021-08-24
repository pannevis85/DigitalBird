import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { PartnerDetailComponent } from './partners/partner-detail/partner-detail.component';
import { PartnerEditComponent } from './partners/partner-edit/partner-edit.component';
import { PartnerListComponent } from './partners/partner-list/partner-list.component';
import { ProcessEditComponent } from './services/process-edit/process-edit.component';
import { ServiceDetailComponent } from './services/service-detail/service-detail.component';
import { ServiceEditComponent } from './services/service-edit/service-edit.component';
import { ServiceListComponent } from './services/service-list/service-list.component';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { VendorDetailComponent } from './vendors/vendor-detail/vendor-detail.component';
import { VendorEditComponent } from './vendors/vendor-edit/vendor-edit.component';
import { VendorListComponent } from './vendors/vendor-list/vendor-list.component';
import { AuthGuard } from './_guards/auth.guard';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path:'',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'users/:userid', component: UserEditComponent, canDeactivate:[PreventUnsavedChangesGuard]},
      {path: 'partners/create', component: PartnerEditComponent},
      {path: 'partners/:partnerid/edit', component: PartnerEditComponent},
      {path: 'partners/:partnerid', component: PartnerDetailComponent},
      {path: 'partners', component: PartnerListComponent},
      {path: 'vendors/create', component: VendorEditComponent},
      {path: 'vendors/:vendorid/edit', component: VendorEditComponent},
      {path: 'vendors/:vendorid', component: VendorDetailComponent},
      {path: 'vendors', component: VendorListComponent},
      {path: 'services/create', component: ServiceEditComponent},
      {path: 'services/:serviceid/edit', component: ServiceEditComponent},
      {path: 'services/:serviceid', component: ServiceDetailComponent},
      {path: 'services', component: ServiceListComponent},
      {path: 'process/create', component: ProcessEditComponent},
      {path: 'process/:serviceid/edit', component: ProcessEditComponent},
      
      {path: 'gdpr', component: HomeComponent},
      {path: 'errors', component: TestErrorsComponent},
      {path: 'not-found', component: NotFoundComponent},
      {path: 'server-error', component: ServerErrorComponent},
      {path: '**', component: NotFoundComponent, pathMatch: 'full'},
    ]
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
