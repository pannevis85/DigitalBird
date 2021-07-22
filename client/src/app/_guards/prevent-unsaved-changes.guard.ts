import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { Observable } from 'rxjs';
import { UserEditComponent } from '../users/user-edit/user-edit.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChangesGuard implements CanDeactivate<unknown> {
  canDeactivate( component: UserEditComponent): boolean {
    if (component.editForm.dirty) {
      return confirm('Are you sure you want to discard unsaved changes?')
    }
    return true;
  }
  
}
