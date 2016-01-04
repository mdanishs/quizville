using System.Collections.Generic;

public interface IDataProvider<T> {

    T GetOne(int index);
    List<T> GetAll();

}
