# Dependy
A (very) simple C# IoC container.

## Usage
### Basic Usage
The basic workflow of Dependy is very similar to many IoC containers:

1. Create a container
2. `Add` dependency registrations
3. `Get` the dependency

In the most simplest form this would look like:

```
IDependyContainer container = new DependyContainer();
container.Add<IMyInterface, MyImplementation>();

var myImplementation = container.Get<IMyInterface>();
```

### Lifecycles
By default Dependy adds registrations as transient, however you can also explicitly configure what lifestyle to use:

```
var container = new DependyContainer();
container.Add<IMyInterface, MySingletonImplementation>(Lifecycle.Singleton);
container.Add<IMyOtherInteface, MyImplementation>(Lifecycle.Transient);
```

### Constructor Parameters
Dependy supports both manual and automatic resolution of constructor parameters.  For the purpose of the following two subsections lets pretend we have an interface `IMyInterface` with an implementation `MyImplementation` that needs a `IUserService` and a `IOrgnisationService` (implemented by `UserService` and `OrganisationService` respectively).

#### Manual Resolution
The parameters can be manually resolved using an `Injector` object as shown in the example below:

```
var container = new DependyContainer();
container.Add<IMyInterface, MyImplementation>(new Injector(new UserService(), new OrganisationService));

var myImplementation = container.Get<IMyInterface>();
```

We could also specify a lifecycle with that:
```
var container = new DependyContainer();
container.Add<IMyInterface, MyImplementation>(new Injector(new UserService(), new OrganisationService), Lifecycle.Singleton);

var myImplementation = container.Get<IMyInterface>();
```

#### Automatic Resolution
The parameters could also be resolved using other registrations, and automatically injected by Dependy on instantiation:
```
var container = new DependyContainer();
container.Add<IUserService, UserService>();
container.Add<IOrganisationService, OrganisationService>();
container.Add<IMyInterface, MyImplementation>();

var myImplementation = container.Get<IMyInterface>();
```

## Future Developments
A number of features are still left to implement:

1. Object disposal
2. Support for multiple registrations of the same interface type
3. Support for registering and retrieving `IEnumerable<T>` registrations
