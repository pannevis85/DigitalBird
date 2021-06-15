import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { PartnerListComponent } from './partners/partner-list/partner-list.component';
import { ProcessComponent } from './process/process.component';
import { VendorListComponent } from './vendors/vendor-list/vendor-list.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path:'',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'members', component: MemberListComponent},
      {path: 'members/:id', component: MemberDetailComponent},
      {path: 'lists', component: ListsComponent},
      {path: 'partners', component: PartnerListComponent},
      {path: 'contacts', component: HomeComponent},
      {path: 'process', component: ProcessComponent},
      {path: 'vendors', component: VendorListComponent},
      {path: 'gdpr', component: HomeComponent},
      {path: '**', component: HomeComponent, pathMatch: 'full'},
    ]
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
