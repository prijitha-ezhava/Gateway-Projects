import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserComponent } from './user.component';

describe('UserComponent', () => {
  let component: UserComponent;
  let fixture: ComponentFixture<UserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });

  it('should say hello', () => {
    // Arrange
    const sayHelloSpy = spyOn(component.speak, 'emit');
    // Act
    component.sayHello();
    // Assert
    expect(sayHelloSpy).toHaveBeenCalled();
    expect(sayHelloSpy).toHaveBeenCalledWith('Hello');
});


it('should say goodbye', () => {
    // Arrange
    const sayGoodbyeSpy = spyOn(component.speak, 'emit');
    // Act
    component.sayGoodbye();
    // Assert
    expect(sayGoodbyeSpy).toHaveBeenCalled();
    expect(sayGoodbyeSpy).toHaveBeenCalledWith('Goodbye');
});

});
