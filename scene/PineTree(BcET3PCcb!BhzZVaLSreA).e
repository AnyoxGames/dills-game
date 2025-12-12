13
3685081939969
404916484712219 1761863301610518400
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -16.4986343383789062,
    "Y": -6.1352300643920898
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404914195960854:1761863301077237200",
  "next_sibling": "404920991244555:1761863302660545600",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404916484984581:1761863301610581100",
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
  "aoid": "404916485102745:1761863301610608600",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404916484984581:1761863301610581100",
    "DefaultRenderer": "404916485151421:1761863301610620000",
    "DepletedRenderer": "404916485135554:1761863301610616300"
  }
},
{
  "cid": 5,
  "aoid": "404916485115903:1761863301610611700",
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
