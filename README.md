# Runtime.Create.Instance
This is a library for instancing classes in external libraries based on interface name at runtime. This allows applications to use different interface implementations without having to change code in order to swap implementations.

## Purpose

Consider an application that reads data from a source. On some projects this source may be a database. On other projects the source may be a file. On other projects it may be someting else. Assuming the application consumes the source the same way, a typical solution is to interface the source, make different implemnentations of the interface and then modify the code to reference and instance the desired implementation.

The problem with this solution is that it creates forks of the base application. One version references one implementation of the interface. A second version references another implementation and so on. Now when the base application needs to be updated, there are multiple copies in existance that need to be updated.

Runtime.Create.Instance attempts to address this solution by allowing the base application to specify the interface but link the desired implementation library at runtime. This allows the desired extenral library to be specified in some manner (such as the command line or a configuration file) and no code changes are needed for the base application to use a different external library implementation.

Ideal for making plugin libraries which can easily be swapped without code changes.

## Usage

The Runtime.Create.Instance library replaces the "new" keyword when instancing a interface implementation from an external library. Below we compare the two methods for a sample ITime interface which implements ClockType1 and ClockType2. Traditionally we instance a class by:

```
ITime clock = new ClockType1();
```

Using the Runtime.Create.Instance library, we don't specify the class - instead we specify the interface. This allows different external library implementations of the interface to use different class names but still allow the library to instance the class. An equivalent instancing using the library would be:

```
ITime clock = Runtime.Create<ITime>.Instance("ClockType1.dll");
```
  
The above statement tells the library to look through the external library "ClockType1.dll" and find a type that implements the ITime interface. In this case, the optional construction parameters were omitted and thus the matching type is instanced without any constructor parameters.

To specify construction parameters, an object array is added which holds the construction parameters. For example:

```
ITime clock = Runtime.Create<ITime>.Instance("ClockType1.dll", new object[] {"Toronto", -5});
```

Lastly, the library supports a second syntax which allows the interface name to be provided as a string. This has anumber of advantages including the fact that the base applictaion does not need to reference the specified interface. Theoretically it can store the instance as a dynamic (which is how this variant returns the instance) and then it can call known methods on the dynamic without actually loading and casting the instance to its interface type. This can be useful when the interface is bundled with an implementation which is not going to be used. In such a case, the library can instance the alternate desired implementation and the interface never needs to be loaded.

The alternate syntax is as follows:

```
ITime clock = Runtime.Create.Instance("Time.ITime", args[0]);
```

or with construction parameters:

```
ITime clock = Runtime.Create.Instance("Time.ITime", args[0], new object[] { "Toronto", -5 } );
```

Which, as discusssed above, can be also kept as dynamic and thus not requiring the base application to instance the interface:

```
dynamic clock = Runtime.Create.Instance("Time.ITime", args[0]);
```

or with construction parameters:

```
dynamic clock = Runtime.Create.Instance("Time.ITime", args[0], new object[] { "Toronto", -5 } );
```
