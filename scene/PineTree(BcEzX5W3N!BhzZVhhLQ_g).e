13
3899830304769
404950318673357 1761863309493866400
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -9.8710699081420898,
    "Y": -9.2779788970947266
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404948387450219:1761863309043889300",
  "next_sibling": "404952249567180:1761863309943766500",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404950318928261:1761863309493925000",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404950319054466:1761863309493954400",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404950318928261:1761863309493925000",
    "DefaultRenderer": "404950319107614:1761863309493966800",
    "DepletedRenderer": "404950319089511:1761863309493962600"
  }
},
{
  "cid": 5,
  "aoid": "404950319066678:1761863309493957200",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
